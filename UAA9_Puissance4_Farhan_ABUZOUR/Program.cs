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

                // Le joueur choisit sa colonne (La méthode s'occupe de demander et vérifier avec LireEntier)
                int colonneChoisie = mesExes.ChoisirColonne(grille);

                // On fait tomber le jeton
                int ligne;
                mesExes.AppliquerGravite(grille, colonneChoisie, joueurActuel, out ligne);

                // 3. Changement de joueur pour le prochain tour
                if (joueurActuel == 1)
                {
                    joueurActuel = 2;
                }
                else
                {
                    joueurActuel = 1;
                }

                // Plus tard : la vérification de victoire 
              
            }
        }
    }
}