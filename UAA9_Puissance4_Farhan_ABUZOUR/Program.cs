using System;

namespace UAA9_Puissance4_Farhan_ABUZOUR
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("==================================================");
            Console.WriteLine("           BIENVENUE DANS PUISSANCE 4 !           ");
            Console.WriteLine("==================================================\n");
            Console.ResetColor();

            Console.Write("Voulez-vous voir les (R)ègles du jeu ou (J)ouer directement ? (Tapez R ou J) : ");
            string choixAccueil = Console.ReadLine().ToUpper();

            if (choixAccueil == "R")
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("---  RÈGLES DU JEU  ---");
                Console.WriteLine("1. Le jeu se joue à deux joueurs.");
                Console.WriteLine("2. À tour de rôle, vous choisissez une colonne (0 à 6) pour y faire tomber votre jeton.");
                Console.WriteLine("3. Le premier joueur qui aligne 4 jetons de sa couleur gagne !");
                Console.WriteLine("   (L'alignement peut être horizontal, vertical ou en diagonale).");
                Console.WriteLine("4. Si la grille est remplie et que personne n'a gagné, c'est un match nul.\n");

                Console.ResetColor();
                Console.WriteLine("Appuyez sur une touche pour lancer la partie...");
                Console.ReadKey(); // Met le jeu en pause jusqu'à ce qu'une touche soit pressée
            }

            
            string rec = "o"; // Variable pour savoir si les joueurs veulent rejouer ou pas
            do
            {
                int[,] grille = new int[6, 7];

                int joueurActuel = 1;
                bool partieEnCours = true;

                while (partieEnCours)
                {
                    // On affiche la grille
                    mesExes.AfficherGrille(grille);

                    // On annonce à qui c'est le tour
                    if (joueurActuel == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.WriteLine("\nC'est au tour du Joueur " + joueurActuel + " !");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine("\nC'est au tour du Joueur " + joueurActuel + " !");
                    }

                    // Le joueur choisit sa colonne
                    Console.ResetColor(); // On remet la couleur à zéro pour la saisie
                    int colonneChoisie = mesExes.ChoisirColonne(grille);

                    // On fait tomber le jeton
                    int ligne;
                    mesExes.AppliquerGravite(grille, colonneChoisie, joueurActuel, out ligne);

                    if (mesExes.VictoireHorizontale(grille, joueurActuel) == true || mesExes.VictoireVerticalement(grille, joueurActuel) == true || mesExes.VictoireDiagonaleDescendante(grille, joueurActuel) == true || mesExes.VictoireDiagonaleMontante(grille, joueurActuel) == true)
                    {
                        // On affiche la grille finale
                        mesExes.AfficherGrille(grille);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\n BRAVO ! Le Joueur " + joueurActuel + " a gagné ! ");
                        Console.ResetColor();

                        partieEnCours = false;
                    }
                    else if (mesExes.GrillePleine(grille) == true)
                    {
                        mesExes.AfficherGrille(grille);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n MATCH NUL ! La grille est pleine, personne n'a gagné. ");
                        Console.ResetColor();

                        partieEnCours = false;
                    }
                    else // Si personne n'a gagné, on passe à l'autre joueur
                    {
                        if (joueurActuel == 1)
                        {
                            joueurActuel = 2;
                        }
                        else
                        {
                            joueurActuel = 1;
                        }
                    }
                }

                Console.WriteLine(); // Petit espace
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Voulez-vous rejouer ? (O/N)");
                Console.ResetColor();

                rec = Console.ReadLine().ToLower();

            } while (rec == "o");

            // Petit message d'au revoir quand on quitte
            Console.WriteLine("Merci d'avoir joué ! À bientôt.");
        }
    }
}