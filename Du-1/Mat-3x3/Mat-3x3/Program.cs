using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;


double[,] matrix_A = new double[3, 3];
double[,] matrix_A1 = new double[3, 3];
double[,] matrix_A2 = new double[3, 3];
double[,] matrix_A3 = new double[3, 3];
double[] matrix_br = new double[12];
double[] matrix_b = new double[3];


//Fulfillment of 3x3 matrix from file

//Path to the file (change to souit your needs): C:\\Users\\drmot\\Nextcloud\\IDT\\Du-1\\Mat-3x3\\Mat-3x3\\matrix.txt
using (StreamReader sr = new StreamReader("C:\\Users\\drmot\\Nextcloud\\IDT\\Du-1\\Mat-3x3\\Mat-3x3\\matrix.txt"))
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                double line = Convert.ToDouble(sr.ReadLine());
                if (line != null)
                {
                    matrix_A[i, j] = line;
                }
                else
                {
                    throw new Exception("The file does not contain enough data for a 3x3 matrix.");
                }
            }
        }
sr.Close();
}

//Fulfillment of 1x12 matrix and assigning the last 3 indexes to matrix_b from file

//Path to the file (change to souit your needs): C:\\Users\\drmot\\Nextcloud\\IDT\\Du-1\\Mat-3x3\\Mat-3x3\\matrix.txt
using (StreamReader sr = new StreamReader("C:\\Users\\drmot\\Nextcloud\\IDT\\Du-1\\Mat-3x3\\Mat-3x3\\matrix.txt"))
{
    for (int i = 0; i < 12; i++)
    {
            double line = Convert.ToDouble(sr.ReadLine());
            if (line != null)
            {
                matrix_br[i] = line;
            }
            else
            {
                throw new Exception("ERR");
            }
    }
sr.Close();


matrix_b[0] = matrix_br[9];
matrix_b[1] = matrix_br[10];
matrix_b[2] = matrix_br[11];
}



for (int i = 0; i < 3; i++)
    { 
        for (int j = 0; j < 3; j++)
    { 
        
            matrix_A1[i, j] = matrix_A[i, j];
            matrix_A2[i, j] = matrix_A[i, j];
            matrix_A3[i, j] = matrix_A[i, j];   

    }
}

//Row swap for cramer
matrix_A1[0,0] = matrix_b[0];
matrix_A1[1,0] = matrix_b[1];
matrix_A1[2, 0] = matrix_b[2];

matrix_A2[0, 1] = matrix_b[0];
matrix_A2[1, 1] = matrix_b[1];
matrix_A2[2, 1] = matrix_b[2];

matrix_A3[0, 2] = matrix_b[0];
matrix_A3[1, 2] = matrix_b[1];
matrix_A3[2, 2] = matrix_b[2];

//Calculation of determinant using sarrus
double detA = (matrix_A[0, 0] * matrix_A[1, 1] * matrix_A[2, 2]) + (matrix_A[1, 0] * matrix_A[2, 1] * matrix_A[0, 2]) +
              (matrix_A[2, 0] * matrix_A[0, 1] * matrix_A[1, 2]) - (matrix_A[0, 2] * matrix_A[1, 1] * matrix_A[2, 0]) -
              (matrix_A[1, 2] * matrix_A[2, 1] * matrix_A[0, 0]) - (matrix_A[2, 2] * matrix_A[0, 1] * matrix_A[1, 0]);

double detA1 = (matrix_A1[0, 0] * matrix_A1[1, 1] * matrix_A1[2, 2]) + (matrix_A1[1, 0] * matrix_A1[2, 1] * matrix_A1[0, 2]) +
              (matrix_A1[2, 0] * matrix_A1[0, 1] * matrix_A1[1, 2]) - (matrix_A1[0, 2] * matrix_A1[1, 1] * matrix_A1[2, 0]) -
              (matrix_A1[1, 2] * matrix_A1[2, 1] * matrix_A1[0, 0]) - (matrix_A1[2, 2] * matrix_A1[0, 1] * matrix_A1[1, 0]);

double detA2 = (matrix_A2[0, 0] * matrix_A2[1, 1] * matrix_A2[2, 2]) + (matrix_A2[1, 0] * matrix_A2[2, 1] * matrix_A2[0, 2]) +
              (matrix_A2[2, 0] * matrix_A2[0, 1] * matrix_A2[1, 2]) - (matrix_A2[0, 2] * matrix_A2[1, 1] * matrix_A2[2, 0]) -
              (matrix_A2[1, 2] * matrix_A2[2, 1] * matrix_A2[0, 0]) - (matrix_A2[2, 2] * matrix_A2[0, 1] * matrix_A2[1, 0]);

double detA3 = (matrix_A3[0, 0] * matrix_A3[1, 1] * matrix_A3[2, 2]) + (matrix_A3[1, 0] * matrix_A3[2, 1] * matrix_A3[0, 2]) +
              (matrix_A3[2, 0] * matrix_A3[0, 1] * matrix_A3[1, 2]) - (matrix_A3[0, 2] * matrix_A3[1, 1] * matrix_A3[2, 0]) -
              (matrix_A3[1, 2] * matrix_A3[2, 1] * matrix_A3[0, 0]) - (matrix_A3[2, 2] * matrix_A3[0, 1] * matrix_A3[1, 0]);

//Finding x,y,z using cramer
double x = detA1 / detA;
double y = detA2 / detA;
double z = detA3 / detA;
Console.WriteLine($"x = {x}\ny = {y}\nz = {z}");


