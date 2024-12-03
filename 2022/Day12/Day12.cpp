#include <iostream>
#include <vector>
#include <fstream>
#include <sstream>
#include <set>

using namespace std;

vector<vector<int>> Read()
{
    string abc = "abcdefghijklmnopqrstuvwxyz";
    vector<string> matrix;
    ifstream inputFile("input.txt");
    inputFile.is_open();
    string line;
    // Read until EOF or blank line
    while (getline(inputFile, line)) {
        istringstream iss(line); // Wrap the line in a stringstream
        matrix.push_back(line);
    }
    inputFile.close();

    vector<vector<int>> graph;
    graph.push_back(vector<int>());
    for (size_t i = 0; i < matrix.size(); i++)
    {
        vector<int> person;
        for (size_t j = 0; j < matrix[i].size(); j++)
        {
            if (matrix[i][j] == 1)
            {
                person.push_back(j+1);
            }
        }
        graph.push_back(person);
    }
    return graph;
}

int abc_index(string n)
{
    string abc = "abcdefghijklmnopqrstuvwxyz";
    int i = 0;
    while (n != to_string(abc[i]) && i != abc.size())
    {
        i++;
    }
    return i;
}

int main()
{
    std::cout << "Hello World!\n";
}
