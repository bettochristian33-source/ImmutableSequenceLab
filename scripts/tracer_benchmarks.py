

import csv
from pathlib import Path
import matplotlib.pyplot as plt

# Dossier racine du projet ImmutableSequenceLab
racine_projet = Path(__file__).resolve().parent.parent

# Chemin vers le fichier CSV
fichier_csv = racine_projet / "assets" / "benchmark-results.csv"

# Listes qui contiendront les données numériques
tailles = []
temps_naif = []
temps_builder = []
ratios = []

with fichier_csv.open("r", encoding="utf-8", newline="") as fichier:
    lecteur = csv.DictReader(fichier)

    for ligne in lecteur:
        tailles.append(int(ligne["Size"]))
        temps_naif.append(float(ligne["NaiveMs"]))
        temps_builder.append(float(ligne["BuilderMs"]))
        ratios.append(float(ligne["Ratio"]))

print("Tailles :", tailles)
print("Temps naïf :", temps_naif)
print("Temps Builder :", temps_builder)
print("Ratios :", ratios)
plt.plot(tailles, temps_naif, label="Méthode naïve")
plt.plot(tailles, temps_builder, label="Builder")
plt.legend()
plt.yscale("log")
plt.title("Comparaison des performances")
plt.xlabel("Taille de la séquence")
plt.ylabel("Temps d'exécution (ms)")
plt.savefig(
    racine_projet / "assets" / "comparaison_performances.png",
    dpi=300,
    bbox_inches="tight"
)
plt.show()
plt.figure()

plt.plot(tailles, ratios, marker="o")

plt.title("Facteur d'accélération du Builder")
plt.xlabel("Taille de la séquence")
plt.ylabel("Accélération (×)")
plt.savefig(
    racine_projet / "assets" / "facteur_acceleration.png",
    dpi=300,
    bbox_inches="tight"
)

plt.show()