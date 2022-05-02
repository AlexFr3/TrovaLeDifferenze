import json
import sqlite3



collectionImmagini = []
with open("Immagini.json", "r") as f:
    collectionImmagini = json.load(f)

collectionDifferenze = []
with open("Differenze.json", "r") as f:
    collectionDifferenze = json.load(f)

connection = sqlite3.connect('Data/DbTrovaLeDifferenze.db')
cursor = connection.cursor()


query = f"DELETE FROM Differenze;"
cursor.execute(query)

query = f"DELETE FROM DomandeImmagine;"
cursor.execute(query)


for i in collectionImmagini:


    query = f"INSERT INTO DomandeImmagine VALUES({i['DomandaImmagineID']},'{i['PercorsoOriginale']}','{i['PercorsoModificata']}',{i['Width']},{i['Height']});"
    cursor.execute(query)

for i in collectionDifferenze:
    query = f"INSERT INTO Differenze VALUES({i['idDifferenza']},{i['X']},{i['Y']},{i['Raggio']},{i['DomandaImmagineId']});"
    cursor.execute(query)

connection.commit()
connection.close()