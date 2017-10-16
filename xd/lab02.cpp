#include <iostream>
#include <cstdlib>
#include <string>
#include <sstream>
#include <vector>

using namespace std;

#define STUDENTS_COUNT 10

class Student {
	private:
		string studentNo;
		string studentIm;
		string studentNz;
		
	public:		
		Student(string studentNo, string studentIm, string studentNz) {
			this->studentIm=studentIm;
			this->studentNo = studentNo;
			this->studentNz = studentNz;
		}
		
		string getStudentNo() {
			return this->studentNo;
		}
		
		string getStudentIm() {
			return this->studentIm;
		}
		
		string getStudentNz() {
			return this->studentNz;
		}
		
		
};

string getRandomStudentNumber() {
	ostringstream ss;
	int randomNumber = rand() % 2000 + 37000;
	
	ss << randomNumber;
	
	return ss.str();

}

string getName()
{
string Name="Imie";
return Name;
}

string getNz()
{
string Name="Nazwisko";
return Name;
}

int main() {
	vector<Student> students;
	
	for(int i = 0; i < STUDENTS_COUNT; i++) {
		Student student(getRandomStudentNumber(),getName(),getNz());
		students.push_back(student);
	}
	
	cout  << "Students group have been filled." << endl << endl;
	
	for(int i = 0; i < students.size(); i++) {
		cout << students.at(i).getStudentNo() << endl;
		cout << students.at(i).getStudentIm() << endl;
		cout << students.at(i).getStudentNz() << endl;
	}	
	return 0;
}
