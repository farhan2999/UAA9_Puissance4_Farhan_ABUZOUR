namespace UAA9_Puissance4_Farhan_ABUZOUR
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int[,] grille = new int[6, 7];
            int joueurActuel = 1; // Le joueur 1 commence
            bool partieEnCours = true; // Permet de faire tourner le jeu

            // 2. Boucle principale du jeu
            while (partieEnCours)
            {
                // On affiche la grille
                mesExes.AfficherGrille(grille);

                // On annonce à qui c'est le tour
                Console.WriteLine("\nC'est au tour du Joueur " + joueurActuel + " !");

                // Le joueur choisit sa colonne
                int colonneChoisie = mesExes.ChoisirColonne(grille);

                // On fait tomber le jeton
                int ligne;
                mesExes.AppliquerGravite(grille, colonneChoisie, joueurActuel, out ligne);

                if (mesExes.VictoireHorizontale(grille, joueurActuel) == true || mesExes.VictoireVerticalement(grille, joueurActuel) == true || mesExes.VictoireDiagonaleDescendante(grille, joueurActuel) == true || mesExes.VictoireDiagonaleMontante(grille, joueurActuel) == true)
                {
                    // On affiche la grille finale
                    mesExes.AfficherGrille(grille);
                    Console.WriteLine("\n BRAVO ! Le Joueur " + joueurActuel + " a gagné !");

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
        }
    }
}