namespace SimpleQRAlgorithm
{
    public static class QRAlgorithm
    {
        /// <summary>
        /// Runs the QR algorithm to find the eigenvalues of the given matrix (see https://en.wikipedia.org/wiki/QR_algorithm).
        /// </summary>
        /// <param name="A">The matrix for which eigenvalues should be found.</param>
        /// <param name="iterations">The number of iterations.</param>
        /// <returns>The eigenvalues of the given matrix.</returns>
        public static float[] Run(float[,] A, int iterations)
        {
            float[,] B = LinearAlgebra.Duplicate(A);

            for (int i = 0; i < iterations; i++)
            {
                QRDecomposition(B, out float[,] Q, out float[,] R);
                B = LinearAlgebra.Product(R, Q);
            }

            // The eigenvalues are on the diagonal of the matrix.
            int n = A.GetLength(0);
            float[] eigenvalues = new float[n];
            for (int i = 0; i < n; i++)
            {
                eigenvalues[i] = B[i, i];
            }

            return eigenvalues;
        }

        /// <summary>
        /// Calculates the QR decomposition of the given matrix A (see https://en.wikipedia.org/wiki/QR_decomposition). 
        /// </summary>
        /// <param name="A">The matrix to decompose.</param>
        /// <param name="Q">The Q part of the decomposition.</param>
        /// <param name="R">The R part of the decomposition.</param>
        private static void QRDecomposition(float[,] A, out float[,] Q, out float[,] R)
        {
            int n = A.GetLength(0);

            float[,] U = LinearAlgebra.Duplicate(A);

            // Calculate the U matrix using the Gram–Schmidt process (see https://en.wikipedia.org/wiki/Gram%E2%80%93Schmidt_process).
            for (int j = 1; j < n; j++)
            {
                float[] u = LinearAlgebra.GetColumn(U, j);
                float[] v = LinearAlgebra.GetColumn(U, j);

                for (int k = j - 1; k >= 0; k--)
                {
                    float[] uk = LinearAlgebra.GetColumn(U, k);
                    u = LinearAlgebra.Subtract(u, LinearAlgebra.Project(uk, v));
                }

                // Update the column entries in U.
                for (int i = 0; i < n; i++)
                {
                    U[i, j] = u[i];
                }
            }

            // Normalize the column vectors of U.
            for (int j = 0; j < n; j++)
            {
                float[] u = LinearAlgebra.GetColumn(U, j);
                float magnitude = LinearAlgebra.Magnitude(u);

                // Update the column entries in U.
                for (int i = 0; i < n; i++)
                {
                    U[i, j] = u[i] / magnitude;
                }
            }

            // The U matrix is now the Q part of the decomposition.
            Q = U;

            // Calculate the R part of the decomposition.
            R = LinearAlgebra.Product(LinearAlgebra.Transpose(Q), A);
        }
    }
}
