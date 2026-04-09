using System.Drawing;

namespace UAA9_Puissance4_Farhan_ABUZOUR
{
    internal class Program
    {
        static void Main(string[] args)
        {

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
                    int colonneChoisie = mesExes.ChoisirColonne(grille);

                    // On fait tomber le jeton
                    int ligne;
                    mesExes.AppliquerGravite(grille, colonneChoisie, joueurActuel, out ligne);


                    if (mesExes.VictoireHorizontale(grille, joueurActuel) == true || mesExes.VictoireVerticalement(grille, joueurActuel) == true || mesExes.VictoireDiagonaleDescendante(grille, joueurActuel) == true || mesExes.VictoireDiagonaleMontante(grille, joueurActuel) == true)
                    {
                        // On affiche la grille finale
                        Console.ForegroundColor = ConsoleColor.Green;
                        mesExes.AfficherGrille(grille);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\n BRAVO ! Le Joueur " + joueurActuel + " a gagné !");

                        partieEnCours = false;
                    }
                    else if (mesExes.GrillePleine(grille) == true)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        mesExes.AfficherGrille(grille);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n MATCH NUL ! La grille est pleine, personne n'a gagné. ");
                        Console.ForegroundColor = ConsoleColor.White;
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

                Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Voulez-vous rejouer ? (O/N)");
                Console.ForegroundColor = ConsoleColor.White;
                rec = Console.ReadLine().ToLower();
            }
            while (rec == "o");


        }
    }
}
