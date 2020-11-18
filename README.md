# SimpleQRAlgorithm

SimpleQRAlgorithm is a C# implementation of the [QR algorithm](https://en.wikipedia.org/wiki/QR_algorithm) for finding the eigenvalues and eigenvectors of a real square matrix.

## Background

The QR Algorithm is a numerically stable algorithm which uses [QR decompositions](https://en.wikipedia.org/wiki/QR_decomposition) to diagonalize any real square matrix. When running the QR Algorithm on a matrix <img src="https://render.githubusercontent.com/render/math?math=A"> for <img src="https://render.githubusercontent.com/render/math?math=k"> iterations, the [Gram-Schmidt process](https://en.wikipedia.org/wiki/Gram%E2%80%93Schmidt_process) is used to decompose the matrix into two components <img src="https://render.githubusercontent.com/render/math?math=Q"> and <img src="https://render.githubusercontent.com/render/math?math=R">, such that <img src="https://render.githubusercontent.com/render/math?math=A= QR">. Then, for some <img src="https://render.githubusercontent.com/render/math?math=k"> iterations, <img src="https://render.githubusercontent.com/render/math?math=A_{k+1} = R_k Q_k">. 

So, in essence, at each iteration the QR Algorithm decomposes the previously obtained matrix into the <img src="https://render.githubusercontent.com/render/math?math=Q"> and <img src="https://render.githubusercontent.com/render/math?math=R"> components. It then calculates the product between <img src="https://render.githubusercontent.com/render/math?math=R"> and <img src="https://render.githubusercontent.com/render/math?math=Q"> to obtain the new matrix. Eventually the algorithm converges and the eigenvalues of the original matrix <img src="https://render.githubusercontent.com/render/math?math=A"> can be found on the diagonal of the resulting matrix <img src="https://render.githubusercontent.com/render/math?math=A_k">. The columns of the <img src="https://render.githubusercontent.com/render/math?math=Q_k"> matrix represent the corresponding eigenvectors. To verify the result, the original matrix <img src="https://render.githubusercontent.com/render/math?math=A"> can be reconstructed from the decomposition <img src="https://render.githubusercontent.com/render/math?math=A = Q_k A_k Q_k^{-1}">.

Eigenvalue algorithms have many applications. For instance, it can be used to calculate the square root of a real square matrix <img src="https://render.githubusercontent.com/render/math?math=\sqrt{A}">. In this case, the matrix can be decomposed using the QR algorithm into <img src="https://render.githubusercontent.com/render/math?math=A = UDU^{-1}">, where <img src="https://render.githubusercontent.com/render/math?math=U"> is the matrix with eigenvectors as columns and <img src="https://render.githubusercontent.com/render/math?math=D"> is the diagonal matrix with the eigenvalues on the diagonal. The square root is then given by <img src="https://render.githubusercontent.com/render/math?math=\sqrt{A} = U \sqrt{D} U^{-1}">, where <img src="https://render.githubusercontent.com/render/math?math=\sqrt{D}"> is the matrix with the square root of the eigenvalues on the diagonal.

## Setup

SimpleQRAlgorithm has no dependencies as it comes with a small linear algebra library, so using it in your project is simple:

1. **Clone** this repository into your project
2. **Import** SimpleQRAlgorithm in your project
3. **Run** the algorithm on any real square matrix

## Example

The following example shows how to run the algorithm on a matrix.

```csharp
// The matrix to run the algorithm on.
float[,] matrix = {
    {1, 2, 3},
    {2, 3, 5},
    {3, 5, 6}
};

// The number of iterations the algorithm should run for.
int numberOfIterations = 10;

// Run the algorithm on the matrix and
// output the matrix' eigenvalues and eigenvectors.
QRAlgorithm.Diagonalize(
    matrix, 
    numberOfIterations, 
    out float[,] eigenvalues, 
    out float[,] eigenvectors
);
```

## Support

If you encounter any bugs, please create an issue with a description and the steps to reproduce the bug on the issues board.
