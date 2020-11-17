# SimpleQRAlgorithm

SimpleQRAlgorithm is a C# implementation of the [QR algorithm](https://en.wikipedia.org/wiki/QR_algorithm) for finding the eigenvalues and eigenvectors of a real square matrix.

## Background
The QR Algorithm is a numerically stable algorithm which uses [QR decompositions](https://en.wikipedia.org/wiki/QR_decomposition) to diagonalize any real square matrix. When running the QR Algorithm on a matrix $A_k$ for $k$ iterations, the [Gram-Schmidt process](https://en.wikipedia.org/wiki/Gram%E2%80%93Schmidt_process) is used to decompose a matrix $A$ into two components $Q$ and $R$, such that $A= QR$. Then, for some $k$ iterations, $A_{k+1} = R_k Q_k$. 

So, in essence, at each iteration the QR Algorithm decomposes the previously obtained matrix into the $Q$ and $R$ components. It then calculates the product between $R$ and $Q$ to obtain the new matrix. Eventually the algorithm converges and the eigenvalues of the original matrix $A$ can be found on the diagonal of the resulting matrix $A_k$. The columns of the $Q_k$ matrix represent the corresponding eigenvectors. To verify the result, the original matrix $A$ can be reconstructed from the decomposition $A = Q_k A_k Q_k^{-1}$.

Eigenvalue algorithms have many applications. For instance, it can be used to calculate the square root of a real square matrix $\sqrt{A}$. In this case, the matrix can be decomposed using the QR algorithm into $A = UDU^{-1}$, where $U$ is the matrix with eigenvectors as columns and $D$ is the diagonal matrix with the eigenvalues on the diagonal. The square root is then given by <img src="https://render.githubusercontent.com/render/math?math=\sqrt{A} = U \sqrt{D} U^{-1}">, where $\sqrt{D}$ is the matrix with the square root of the eigenvalues on the diagonal.

## Setup
SimpleQRAlgorithm has no dependencies, so using it in your project is simple:

1. **Clone** this repository into your project
2. **Import** SimpleQRAlgorithm in your project
3. **Run** the algorithm on any real square matrix

## Example