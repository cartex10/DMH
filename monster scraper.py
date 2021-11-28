import bs4, requests
from enum import Enum
import xml.etree.ElementTree as ET
import imgkit

class Creature:
	name = "" #
	ac = 10 #
	pp = 10 #
	str = [0, 0, 0] #
	dex = [0, 0, 0] #
	con = [0, 0, 0] #
	int_stat = [0, 0, 0] #
	wis = [0, 0, 0] #
	cha = [0, 0, 0] #
	dmg = [0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0] #
	playable = False #
	evasion = False #
	max_hp = 1 #
	level = 1 #
	user_created = False

class dmgtypes(Enum):
	acid = 0
	cold = 1
	fire = 2
	force = 3
	lightning = 4
	necrotic = 5
	poison = 6
	psychic = 7
	radiant = 8
	thunder = 9
	bludgeoning = 10
	piercing = 11
	slashing = 12

###
###
###	CHANGE VARIABLES BELOW TO SAVE EITHER FILE
###
###

do_xml = False
do_jpg = False

res = requests.get('https://www.aidedd.org/dnd-filters/monsters.php')
thesoup = bs4.BeautifulSoup(res.text, 'html.parser')


selected = thesoup.select('form[name="selections"] div[class="col"] table[class="liste"] td[class="nocel"] input[value]')
monsters = []
for i in selected:
	monsters.append(i.attrs['value'][1:-1])

with open("default_monsters/enum.cs", "w") as file:
	file.write("namespace Dungeon_Master_Helper\n{\n\tpublic enum monsters\n\t{\n")

for i in monsters:

	###
	###
	###	CREATE AND FILL CREATURE
	###
	###

	temp = Creature()
	name = i.replace("--", "'-")
	name = name.split("-")
	for j in name:
		if len(j) > 1:
			temp.name += j[0].upper() + j[1:] + " "
		else:
			temp.name += j
	temp.name = temp.name[:-1]
	print(temp.name)
	res = requests.get('https://www.aidedd.org/dnd/monstres.php?vo=' + i)
	thesoup = bs4.BeautifulSoup(res.text, 'html.parser')

	selected = thesoup.select('p[class="warning"]')
	if len(selected) != 0:
		continue

	with open("default_monsters/enum.cs", "a") as file:
		file.write("\t\t"+ i.replace("-", "_") + ",\n")

	selected = thesoup.select('div[class="red"]')
	text = str(selected[0])

	text = text[text.index("</strong>")+10:]
	try:
		if text.index("(") < text.index("<"):
			temp.ac = int(text[:text.index("(")])
		else:
			temp.ac = int(text[:text.index("<")])
	except:
		temp.ac = 11
		print("Error with " + temp.name + "'s ac")

	text = text[text.index("</strong>")+10:]
	temp.max_hp = int(text[:text.index(" ")])

	text = text[text.index("STR</strong>")+17:]
	temp.str[0] = int(text[:text.index(" ")])
	temp.str[2] = int(text[text.index("(")+2:text.index(")")])

	text = text[text.index("DEX</strong>")+17:]
	temp.dex[0] = int(text[:text.index(" ")])
	temp.dex[2] = int(text[text.index("(")+2:text.index(")")])

	text = text[text.index("CON</strong>")+17:]
	temp.con[0] = int(text[:text.index(" ")])
	temp.con[2] = int(text[text.index("(")+2:text.index(")")])

	text = text[text.index("INT</strong>")+17:]
	temp.int_stat[0] = int(text[:text.index(" ")])
	temp.int_stat[2] = int(text[text.index("(")+2:text.index(")")])

	text = text[text.index("WIS</strong>")+17:]
	temp.wis[0] = int(text[:text.index(" ")])
	temp.wis[2] = int(text[text.index("(")+2:text.index(")")])

	text = text[text.index("CHA</strong>")+17:]
	temp.cha[0] = int(text[:text.index(" ")])
	temp.cha[2] = int(text[text.index("(")+2:text.index(")")])

	if text.find("vulnerabilities") != -1:
		text = text[text.index("vulnerabilities") + 25:]
		dmg = text[:text.index("<")]
		dmg = dmg.replace(";", ",")
		dmg = dmg.replace(" and ", ", ")
		dmg = dmg.replace(",,", ",")
		if dmg.find(", ") == -1:
			dmg = [dmg]
		else:
			dmg = dmg.split(", ")
		for j in dmg:
			try:
				ind = dmgtypes[j].value
				temp.dmg[ind] = 3
			except:
				pass

	if text.find("Resistances") != -1:
		text = text[text.index("Resistances") + 21:]
		dmg = text[:text.index("<")]
		dmg = dmg.replace(";", ",")
		dmg = dmg.replace(" and ", ", ")
		dmg = dmg.replace(",,", ",")
		if dmg.find(", ") == -1:
			dmg = [dmg]
		else:
			dmg = dmg.split(", ")
		if dmg[-1].endswith("attacks"):
			dmg[-1] = dmg[-1][:-24]
		for j in dmg:
			try:
				ind = dmgtypes[j].value
				temp.dmg[ind] = 2
			except:
				pass

	if text.find("Immunities") != -1:
		text = text[text.index("Immunities") + 20:]
		dmg = text[:text.index("<")]
		dmg = dmg.replace(";", ",")
		dmg = dmg.replace(" and ", ", ")
		dmg = dmg.replace(",,", ",")
		if dmg.find(", ") == -1:
			dmg = [dmg]
		else:
			dmg = dmg.split(", ")
		if dmg[-1].endswith("attacks"):
			dmg[-1] = dmg[-1][:-24]
		for j in dmg:
			try:
				ind = dmgtypes[j].value
				temp.dmg[ind] = 1
			except:
				pass

	try:
		text = text[text.index("Senses"):]
		text = text[text.index("Perception") + 11:]
		temp.pp = int(text[:text.index("<")])
	except:
		print("Error with " + temp.name + "'s pp")

	text = text[text.index("Challenge") + 19:]
	if text[:text.index("(") - 1].find("/") != -1:
		temp.level = 0
	else:
		temp.level = int(text[:text.index("(") - 1])

	selected = thesoup.select('div[class="sansSerif"] p strong')
	if selected[0].find("Evasion") != -1:
		temp.evasion = True

	###
	###
	###	SAVE TO XML
	###
	###

	if do_xml:
		toSave = ET.Element("Creature")
		toSave.set("xmlns:xsd", "http://www.w3.org/2001/XMLSchema")
		toSave.set("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance")
		name = ET.SubElement(toSave, "name")
		name.text = temp.name
		ac = ET.SubElement(toSave, "ac")
		ac.text = str(temp.ac)
		pp = ET.SubElement(toSave, "pp")
		pp.text = str(temp.pp)

		str_stat = ET.SubElement(toSave, "str")
		str_stat0 = ET.SubElement(str_stat, "int")
		str_stat0.text = str(temp.str[0])
		str_stat1 = ET.SubElement(str_stat, "int")
		str_stat1.text = "0"
		str_stat2 = ET.SubElement(str_stat, "int")
		str_stat2.text = str(temp.str[2])

		dex = ET.SubElement(toSave, "dex")
		dex0 = ET.SubElement(dex, "int")
		dex0.text = str(temp.dex[0])
		dex1 = ET.SubElement(dex, "int")
		dex1.text = "0"
		dex2 = ET.SubElement(dex, "int")
		dex2.text = str(temp.dex[2])

		con = ET.SubElement(toSave, "con")
		con0 = ET.SubElement(con, "int")
		con0.text = str(temp.con[0])
		con1 = ET.SubElement(con, "int")
		con1.text = "0"
		con2 = ET.SubElement(con, "int")
		con2.text = str(temp.con[2])

		int_stat = ET.SubElement(toSave, "int_stat")
		int_stat0 = ET.SubElement(int_stat, "int")
		int_stat0.text = str(temp.int_stat[0])
		int_stat1 = ET.SubElement(int_stat, "int")
		int_stat1.text = "0"
		int_stat2 = ET.SubElement(int_stat, "int")
		int_stat2.text = str(temp.int_stat[2])

		wis = ET.SubElement(toSave, "wis")
		wis0 = ET.SubElement(wis, "int")
		wis0.text = str(temp.wis[0])
		wis1 = ET.SubElement(wis, "int")
		wis1.text = "0"
		wis2 = ET.SubElement(wis, "int")
		wis2.text = str(temp.wis[2])

		cha = ET.SubElement(toSave, "cha")
		cha0 = ET.SubElement(cha, "int")
		cha0.text = str(temp.cha[0])
		cha1 = ET.SubElement(cha, "int")
		cha1.text = "0"
		cha2 = ET.SubElement(cha, "int")
		cha2.text = str(temp.cha[2])

		dmg = ET.SubElement(toSave, "dmg")
		dmgstore = []
		for j in temp.dmg:
			dmgstore.append(ET.SubElement(dmg, "int"))
			dmg[-1].text = str(j)

		playable = ET.SubElement(toSave, "playable")
		playable.text = "false"
		evasion = ET.SubElement(toSave, "evasion")
		if temp.evasion:
			evasion.text = "true"
		else:
			evasion.text = "false"
		max_hp = ET.SubElement(toSave, "max_hp")
		max_hp.text = str(temp.max_hp)
		level = ET.SubElement(toSave, "level")
		level.text = str(temp.level)
		user_created = ET.SubElement(toSave, "user_created")
		if temp.user_created:
			user_created.text = "true"
		else:
			user_created.text = "false"

		toSave = ET.tostring(toSave)
		with open("default_monsters/"+i+".creature.xml", "wb") as file:
			file.write(toSave)

	###
	###
	###	SAVE TO JPG
	###
	###

	if do_jpg:
		selected = thesoup.select('div[class="jaune"]')
		imgkit.from_string(str(selected[0]), "default_monsters/" + i + ".jpg")

	print(temp.name)
	print("--------------------------------------")

with open("default_monsters/enum.cs", "a") as file:
	file.write("\t}\n}")
