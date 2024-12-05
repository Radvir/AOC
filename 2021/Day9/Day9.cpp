#include <iostream>
#include <vector>
#include <fstream>
#include <sstream>
#include <set>

using namespace std;

vector<vector<int>> Read()
{
    vector<vector<int>> matrix;
    ifstream inputFile("input.txt");
    inputFile.is_open();
    string line;
    // Read until EOF or blank line
    while (getline(inputFile, line)) {
        istringstream iss(line);
        vector<int> values;
        string value;
        while (getline(iss, value, '\t')) {
            values.push_back(stoi(value));
        }
        matrix.push_back(values);
    }
    inputFile.close();

    vector<vector<int>> result_matrix;
    vector<int> nulls(matrix.size()+1, {-1});
    result_matrix.push_back(nulls);
    for (size_t i = 0; i < matrix.size(); i++)
    {
        vector<int> temp;
        temp.push_back(-1);
        for (size_t j = 0; j < matrix[i].size(); j++)
        {
            temp.push_back(matrix[i][j]);
        }
        temp.push_back(-1);        
    }
    result_matrix.push_back(nulls);
    
    return result_matrix;
}

int Solve(vector<vector<int>> matrix)
{
    int result = 0;

    for (size_t i = 1; i < matrix.size()-1; i++)
    {
        for (size_t j = 1; j < matrix[i].size()-1; j++)
        {
            int self = matrix[i][j];
            bool isRisky = true;
            /*
            matrix[i+1][j] fel
            matrix[i][j-1] bal
            matrix[i][j+1] jobb
            matrix[i-1][j] le
            */
            if (self != -1 && matrix[i+1][j] < self) // TODO
            {
                /* code */
            }
            
        }
        
    }
    
}

int main()
{
    std::cout << "Hello World!\n";
}
