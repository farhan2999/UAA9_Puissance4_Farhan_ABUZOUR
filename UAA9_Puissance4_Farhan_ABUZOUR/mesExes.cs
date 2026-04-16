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
        /// <summary>
        /// Affiche la grille avec les couleurs classiques du Puissance 4 (Grille bleue, Jetons Rouges/Jaunes)
        /// </summary>
        public static void AfficherGrille(int[,] grille)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n       PUISSANCE 4");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("  =====================\n");
            Console.ForegroundColor = ConsoleColor.White;

            for (int iLigne = 0; iLigne < grille.GetLength(0); iLigne++)
            {
                // On dessine le bord gauche en bleu
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.Write("|");

                for (int iColonne = 0; iColonne < grille.GetLength(1); iColonne++)
                {
                    string symbole = " ";
                    int valeurCase = grille[iLigne, iColonne];

                    // On choisit la couleur et le symbole en fonction du contenu de la case
                    ConsoleColor couleurJeton = ConsoleColor.White;

                    if (valeurCase == 1) // Joueur 1 normal
                    {
                        symbole = "O";
                        couleurJeton = ConsoleColor.Red;
                    }
                    else if (valeurCase == 2) // Joueur 2 normal
                    {
                        symbole = "O";
                        couleurJeton = ConsoleColor.Yellow;
                    }
                    else if (valeurCase == 11 || valeurCase == 12) // Jetons GAGNANTS
                    {
                        symbole = "O";
                        couleurJeton = ConsoleColor.Green; // Vert éclatant pour la victoire
                    }

                    // On dessine le jeton avec sa couleur
                    Console.ForegroundColor = couleurJeton;
                    Console.Write(" " + symbole + " ");

                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.Write("|");
                }
                Console.WriteLine();
            }

            // Le bas de la grille en bleu
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("-----------------------------");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("[ 0   1   2   3   4   5   6 ]");

            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("-----------------------------");

           
            Console.ResetColor();
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
                Console.ForegroundColor = ConsoleColor.White;
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
        /// Cette méthode vérifie s'il y a une victoire horizontale pour le joueur donné, en parcourant le plateau et en cherchant 4 jetons consécutifs du même joueur
        /// </summary>
        /// <param name="tab">Le plateau de jeu</param>
        /// <param name="joueur">Le numéro du joueur (1 ou 2) pour lequel on veut vérifier la victoire</param>  
        /// <param name="booléen"></param>
        /// <returns></returns>
        public static bool VictoireHorizontale(int[,] tab, int joueur)
        {
            for (int iLigne = 0; iLigne <= 5; iLigne++)
            {
                for (int iColonne = 0; iColonne <= 3; iColonne++)
                {
                    if (tab[iLigne, iColonne] == joueur &&
                        tab[iLigne, iColonne + 1] == joueur &&
                        tab[iLigne, iColonne + 2] == joueur &&
                        tab[iLigne, iColonne + 3] == joueur)
                    {
                        
                        tab[iLigne, iColonne] = joueur + 10;
                        tab[iLigne, iColonne + 1] = joueur + 10;
                        tab[iLigne, iColonne + 2] = joueur + 10;
                        tab[iLigne, iColonne + 3] = joueur + 10;

                        return true; 
                    }
                }
            }
            return false;
        }
        /// <summary>
        ///  vérifier si le joueur qui vient de jouer à aligner 4 jetons de sa couleur sur une même ligne
        /// </summary>
        /// <param name="tab">La grille de jeu (6 lignes, 7 colonnes)</param>
        /// <param name="joueur">joueur  1 ou 2</param>
        /// <returns></returns>
        public static bool VictoireVerticalement(int[,] tab, int joueur)
        {
            for (int iColonne = 0; iColonne <= 6; iColonne++)
            {
                for (int iLigne = 2; iLigne >= 0; iLigne--)
                {
                    if (tab[iLigne, iColonne] == joueur &&
                        tab[iLigne + 1, iColonne] == joueur &&
                        tab[iLigne + 2, iColonne] == joueur &&
                        tab[iLigne + 3, iColonne] == joueur)
                    {
                        tab[iLigne, iColonne] = joueur + 10;
                        tab[iLigne +1, iColonne] = joueur + 10;
                        tab[iLigne + 2, iColonne] = joueur + 10;
                        tab[iLigne + 3, iColonne] = joueur + 10;

                        return true;
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// Cette méthode vérifie s'il y a une victoire en diagonale descendante pour le joueur donné, en parcourant le plateau et en cherchant 4 jetons consécutifs du même joueur dans une diagonale descendante (de haut-gauche à bas-droite)
        /// </summary>
        /// <param name="tab">La grille de jeu (6 lignes, 7 colonnes)</param>
        /// <param name="joueur">joueur  1 ou 2</param>
        /// <returns></returns>
        public static bool VictoireDiagonaleDescendante(int[,] tab, int joueur)
        {
            for (int iLigne = 0; iLigne <= 2; iLigne++)
            {
                for (int iColonne = 0; iColonne <= 3; iColonne++)
                {
                    if (tab[iLigne, iColonne] == joueur &&
                        tab[iLigne+1, iColonne + 1] == joueur &&
                        tab[iLigne+2, iColonne + 2] == joueur &&
                        tab[iLigne+3, iColonne + 3] == joueur)
                    {

                        tab[iLigne, iColonne] = joueur + 10;
                        tab[iLigne +1, iColonne + 1] = joueur + 10;
                        tab[iLigne +2, iColonne + 2] = joueur + 10;
                        tab[iLigne+3, iColonne + 3] = joueur + 10;

                        return true;
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// Cette méthode vérifie s'il y a une victoire en diagonale montante pour le joueur donné, en parcourant le plateau et en cherchant 4 jetons consécutifs du même joueur dans une diagonale montante (de bas-gauche à haut-droite)
        /// </summary>
        /// <param name="tab">La grille de jeu (6 lignes, 7 colonnes)</param>
        /// <param name="joueur">joueur  1 ou 2</param>
        /// <returns></returns>
        public static bool VictoireDiagonaleMontante(int[,] tab, int joueur)
        {
            for (int iLigne = 3; iLigne <= 5; iLigne++)
            {
                for (int iColonne = 0; iColonne <= 3; iColonne++)
                {
                    if (tab[iLigne, iColonne] == joueur &&
                        tab[iLigne - 1, iColonne + 1] == joueur &&
                        tab[iLigne - 2, iColonne + 2] == joueur &&
                        tab[iLigne - 3, iColonne + 3] == joueur)
                    {

                        tab[iLigne, iColonne] = joueur + 10;
                        tab[iLigne - 1, iColonne + 1] = joueur + 10;
                        tab[iLigne - 2, iColonne + 2] = joueur + 10;
                        tab[iLigne - 3, iColonne + 3] = joueur + 10;

                        return true;
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// Vérifie si la grille est totalement pleine (match nul)
        /// </summary>
        /// <param name="tab">La grille de jeu (6 lignes, 7 colonnes)</param>
        /// <returns></returns>
        public static bool GrillePleine(int[,] tab)
        {
            for (int iColonne = 0; iColonne <= 6; iColonne++)
            {
                if (tab[0, iColonne] == 0)
                {
                    return false; 
                }
            }
            return true;
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
