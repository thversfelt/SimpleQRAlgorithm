using System;

namespace SimpleQRAlgorithm
{
    public static class LinearAlgebra
    {
        /// <summary>
        /// Gets the j-th column of the given matrix.
        /// </summary>
        /// <param name="A">The matrix.</param>
        /// <param name="j">The index of the column.</param>
        /// <returns>The column vector.</returns>
        public static float[] GetColumn(float[,] A, int j)
        {
            int n = A.GetLength(0);
            float[] column = new float[n];
            for (int i = 0; i < n; i++)
            {
                column[i] = A[i, j];
            }
            return column;
        }

        /// <summary>
        /// Duplicates the given matrix.
        /// </summary>
        /// <param name="A">The matrix to duplicate.</param>
        /// <returns>The duplicated matrix.</returns>
        public static float[,] Duplicate(float[,] A)
        {
            int n = A.GetLength(0);
            float[,] B = new float[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    B[i, j] = A[i, j];
                }
            }

            return B;
        }

        /// <summary>
        /// Scales the given vector by a scalar.
        /// </summary>
        /// <param name="a">The vector to scale.</param>
        /// <param name="s">The scalar.</param>
        /// <returns></returns>
        public static float[] Scale(float[] a, float s)
        {
            for (int i = 0; i < a.Length; i++)
            {
                a[i] *= s;
            }
            return a;
        }

        /// <summary>
        /// Calculates the inner product between two vectors.
        /// </summary>
        /// <param name="a">The first vector.</param>
        /// <param name="b">The second vector.</param>
        /// <returns>The inner product.</returns>
        public static float InnerProduct(float[] a, float[] b)
        {
            float product = 0;
            for (int i = 0; i < a.Length; i++)
            {
                product += a[i] * b[i];
            }
            return product;
        }

        /// <summary>
        /// Projects the vector "a" orthogonally onto vector "u".
        /// </summary>
        /// <param name="a">The vector to project.</param>
        /// <param name="b">The vector on which will be projected.</param>
        /// <returns>The projection.</returns>
        public static float[] Project(float[] a, float[] b)
        {
            return Scale(a, InnerProduct(a, b) / InnerProduct(a, a));
        }

        /// <summary>
        /// Substracts vector "b" from vector "a".
        /// </summary>
        /// <param name="a">The vector to be subtracted.</param>
        /// <param name="b">The substracting vector.</param>
        /// <returns>The substracted vector.</returns>
        public static float[] Subtract(float[] a, float[] b)
        {
            for (int i = 0; i < a.Length; i++)
            {
                a[i] -= b[i];
            }
            return a;
        }

        /// <summary>
        /// Multiplies matrix A with matrix B.
        /// </summary>
        /// <param name="A">The first matrix.</param>
        /// <param name="B">The second matrix.</param>
        /// <returns>The resulting matrix.</returns>
        public static float[,] Product(float[,] A, float[,] B)
        {
            int n = A.GetLength(0);
            float[,] C = new float[n, n];

            for (int i = 0; i < n; ++i)
            {
                for (int j = 0; j < n; ++j)
                {
                    for (int k = 0; k < n; ++k)
                    {
                        C[i, j] += A[i, k] * B[k, j];
                    }
                }
            }

            return C;
        }

        /// <summary>
        /// Calculates the transpose of the given matrix.
        /// </summary>
        /// <param name="A">The matrix to transpose.</param>
        /// <returns>The transpose.</returns>
        public static float[,] Transpose(float[,] A)
        {
            int n = A.GetLength(0);
            float[,] B = new float[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    B[i, j] = A[j, i];
                }
            }

            return B;
        }

        /// <summary>
        /// Calculates the magnitude of the given vector.
        /// </summary>
        /// <param name="a">The vector to compute the magnitude of.</param>
        /// <returns>The magnitude.</returns>
        public static float Magnitude(float[] a)
        {
            float magnitude = 0;
            for (int i = 0; i < a.Length; i++)
            {
                magnitude += a[i] * a[i];
            }
            return (float)Math.Sqrt(magnitude);
        }

        /// <summary>
        /// Prints the given matrix.
        /// </summary>
        /// <param name="A">The matrix to print.</param>
        /// <returns>The string representation of the given matrix.</returns>
        public static string ToString(float[,] A)
        {
            int n = A.GetLength(0);
            string text = "";

            for (int i = 0; i < n; i++)
            {
                if (i > 0) text += ',';

                text += '{';
                for (int j = 0; j < n; j++)
                {
                    if (j > 0) text += ',';
                    text += A[i, j];
                }
                text += '}';
            }
            return text;
        }

        /// <summary>
        /// Prints the given vector.
        /// </summary>
        /// <param name="a">The vector to print.</param>
        /// <returns>The string representation of the given vector.</returns>
        public static string ToString(float[] a)
        {
            string text = "{";
            for (int i = 0; i < a.Length; i++)
            {
                if (i > 0) text += ',';
                text += a[i];
            }
            text += '}';
            return text;
        }
    }
}