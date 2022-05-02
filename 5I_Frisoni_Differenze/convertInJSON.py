import json
linesImmagini = []
linesDifferenze = []
with open("Immagini.csv") as f:
    f.readline()
    linesImmagini = f.readlines()

with open("Differenze.csv") as f:
    f.readline()
    linesDifferenze = f.readlines()


immaginiJSON = []
differenzeJSON = []

for i in linesImmagini:
    i = i.replace("\n", "")
    fields = i.split(";")
    immaginiJSON.append({
        "DomandaImmagineID": int(fields[0]),
        "PercorsoOriginale": fields[1],
        "PercorsoModificata": fields[2],
        "Width": int(fields[3]),
        "Height": int(fields[4])
    })

for i in linesDifferenze:
    i = i.replace("\n", "")
    fields = i.split(";")
    differenzeJSON.append({
        "idDifferenza": int(fields[0]),
        "X": int(fields[1]),
        "Y": int(fields[2]),
        "Raggio": int(fields[3]),
        "DomandaImmagineId": int(fields[4])
    })


with open("Immagini.json", "w") as f:
    json.dump(immaginiJSON, f, indent=3)

with open("Differenze.json", "w") as f:
    json.dump(differenzeJSON, f, indent=3)