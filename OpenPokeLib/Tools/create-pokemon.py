import json

name = input("Name:")

data = {}
data['BaseStats'] = {
    "Hp":int(input("Hp:")),
    "Attack":int(input("Attack:")),
    "Defense":int(input("Defense:")),
    "SpecialAttack":int(input("SpecialAttack:")),
    "SpecialDefense":int(input("SpecialDefense:")),
    "Speed":int(input("Speed:"))
}
data['GenderThreshold'] = int(input("Gender Threshold:"))
data['CatchRate'] = int(input("Catch Rate:"))

groups = input("Egg Groups:")
data['EggGroups'] = groups.split(' ')

data['HatchTime'] = [int(input("Hatch Time 1:")),int(input("Hatch Time 2:"))]
data['Height'] = float(input("Height:"))
data['Weight'] = float(input("Weight:"))
data['BaseExperienceYield'] = int(input("Base Experience Yield:"))
data['LevelingRate'] = input("Leveling Rate:")

types = input("Types:")
data['Types'] = types.split(' ')
data['Abilities'] = input("Abilities:").split(" ")

ev_yield = input("EV Yield:").split(" ")
data['EVYield'] = {}
i = 0
while(i < len(ev_yield)-1):
    data['EVYield'] = {
        ev_yield[i]:int(ev_yield[i+1])
    }
    i+=2

data['BaseFriendship'] = int(input("Base Friendship:"))
data['EvolutionLevel'] = int(input("Evolution Level:"))
data['Evolution'] = input('Evolution:')
data['Description'] = input('Description:')

print(json.dumps(data, indent=4, sort_keys=True))
with open(f'{name}.json','w') as outfile:
    outfile.write(json.dumps(data))