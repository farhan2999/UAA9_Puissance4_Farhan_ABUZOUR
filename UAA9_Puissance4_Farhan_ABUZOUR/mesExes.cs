using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAA9_Puissance4_Farhan_ABUZOUR
{
    public static class mesExes
    {
        /// <summary>
        /// Cette méthode affiche la grille de jeu dans la console, en remplaçant les chiffres par des symboles visuels pour une meilleure lisibilité
        /// </summary>
        /// <param name="grille"></param> 
        public static void AfficherGrille(int[,] grille)
        {
            Console.Clear(); // Optionnel : nettoie l'écran à chaque tour pour faire plus propre
            for (int iLigne = 0; iLigne < grille.GetLength(0); iLigne++)
            {
                Console.Write("|");

                for (int iColonne = 0; iColonne < grille.GetLength(1); iColonne++)
                {
                   // Remplacer les chiffres par des symboles visuels
                    string symbole = " ";
                    if (grille[iLigne, iColonne] == 1) symbole = "X"; // Jeton Joueur 1
                    if (grille[iLigne, iColonne] == 2) symbole = "O"; // Jeton Joueur 2
                    Console.Write(" " + symbole + " |");

                }
                Console.WriteLine(); 
            }
            Console.WriteLine("-----------------------------");
            Console.WriteLine("| 0   1   2   3   4   5   6 |");
            Console.WriteLine("-----------------------------");
        }
        /// <summary>
        /// Cette méthode demande au joueur de choisir une colonne, et vérifie que la saisie est valide (entre 0 et 6, et que la colonne n'est pas pleine)
        /// </summary>
        /// <param name="tab"> </param>
        /// <returns></returns>
        public static int ChoisirColonne(int[,] tab)
        {
            int colonneIndex;
            bool saisieValide;

            do
            {
                // 1. On utilise TA méthode LireEntier ici !
                colonneIndex = LireEntier("Entrez le numéro de la colonne (0 à 6) : ");

                saisieValide = true; // On part du principe que c'est bon, puis on vérifie les règles

                // 2. Vérifier si le nombre est en dehors du plateau
                if (colonneIndex < 0 || colonneIndex > 6)
                {
                    saisieValide = false;
                    Console.WriteLine("Erreur : Veuillez entrer un nombre entre 0 et 6.\n");
                }
                // 3. Vérifier si la colonne est pleine (la case tout en haut [0] n'est plus à 0)
                else if (tab[0, colonneIndex] != 0)
                {
                    saisieValide = false;
                    Console.WriteLine("Erreur : Cette colonne est pleine. Choisissez une autre colonne.\n");
                }
            } while (!saisieValide); // On recommence tant que ce n'est pas valide
            return colonneIndex;
        }
        /// <summary>
        /// Cette méthode fait tomber un jeton dans la colonne choisie, en respectant la gravité du jeu (le jeton s'arrête sur le premier jeton rencontré ou au fond de la colonne)
        /// </summary>
        /// <param name="tab">Le plateau de jeu</param> 
        /// <param name="colonneChoisie">La colonne dans laquelle le joueur veut faire tomber son jeton</param>
        /// <param name="jeton">Le numéro du joueur (1 ou 2) qui correspond au jeton à faire tomber</param> 
        /// <param name="ligneTrouvee">Cette méthode fait tomber le jeton dans la colonne choisie, et retourne la ligne où le jeton s'est arrêté</param>
        public static void AppliquerGravite(int[,] tab, int colonneChoisie, int jeton, out int ligneTrouvee)
        {
            ligneTrouvee = -1;
            bool caseVideTrouvee = false;

            for (int iLigne = 5; iLigne >= 0; iLigne--)
            {
                if (tab[iLigne, colonneChoisie] == 0)
                {
                    tab[iLigne, colonneChoisie] = jeton;
                    ligneTrouvee = iLigne;
                    caseVideTrouvee = true;
                    break;
                }
            }
        }
        /// <summary>
        /// Cette méthode demande à l'utilisateur de saisir un entier, et vérifie que la saisie est bien un entier avant de le retourner
        /// </summary>
        /// <param name="question"></param> 
        /// <returns></returns>
        public static int LireEntier(string question)
        {
            int entier;
            do
            {
                Console.Write(question);

            } while (!int.TryParse(Console.ReadLine(), out entier));

            return entier;

        }
    }
}
