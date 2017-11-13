#include <iostream>
#include <stdlib.h>
#include <time.h>
#include <vector>
#include <string>
#include <sstream>
#include <cstdlib>
#include <iomanip>
 
using namespace std;
class Student
{
    private:
        int indeks;
        int pesel[11];
        string imie;
        string nazwisko;
        string adres;
        string rok;
 
    public:
        Student()
        {
        }
 
    void wyswietlStudenta()
        {
            cout<< this->indeks << "\t";
            for(int x = 0; x < 11; x++)
                cout << pesel[x];
            cout<<"\t"<< "\t"<<this->imie << "\t" <<this->nazwisko<< "\t" <<this->adres<<"\t"<<this->rok<<endl;
        }
 
        void setIndeks(int indeks)
        {
            this->indeks = indeks;
        }
 
        void setPesel()
        {
            int znak;
            for(int x = 0; x < 11; x++)
            {
            	cout<<"Podaj "<<x+1<<" cyfre:"<<endl;
                cin>>znak;
                pesel[x] = znak;
            }
        }              
        
        void setImie(string imie)
        {
            this->imie = imie;
        }
 
        void setAdres(string adres)
        {
            this->adres = adres;
        }
 
        void setRok(string rok)
        {
            this->rok = rok;
        }
 
        void setNazwisko(string nazwisko)
        {
            this->nazwisko = nazwisko;
        }
        
        int getPesel(int i)
        {
            return pesel[i];
        }
        
        /*void setPesel1()
        {
            for(int i = 0; i < 11; i ++)
                pesel[i] = 0;
        }*/
};
int main(int argc, char** argv) {
int dodawanieStudenta(0);
int numer(0);
 
vector<Student>VectorStudent;
 
while(numer!=3)
{
cout <<"Wybierz: [1] pokaz liste studentow, [2] dodaj studenta, [3] wyjdz z programu"<< endl;
cin>>numer;
 
    switch (numer)
    {
 
    case 1: // pokaz studenta
    {
 
    if(dodawanieStudenta==0)
        {
    cout << "Lista studentow jest pusta" << endl;
        }
    else
        {
        cout << "numer indeksu, PESEL, nazwisko, imie, adres, rok;" << endl;
        for(int i = 0; i < VectorStudent.size(); i++)
        {
        VectorStudent.at(i).wyswietlStudenta();
        }
        //wypisywanie studenciakow
        }
    break;
    }
 
 
 
    case 2: // dodwanie studenta
    {
 
    string imie;
    string nazwisko;
    int pesel;
    int indeks;
    string adres;
    string rok;
    int rok1;
 
    Student student;
 
    cout << "podaj numer indeksu studenta:" << endl;
    cin>>indeks;
    student.setIndeks(indeks);
 
    cout << "podaj PESEL studenta:" << endl;
    student.setPesel();
    if(student.getPesel(0) == 8 || student.getPesel(0) == 9 && student.getPesel(1)>=0 && student.getPesel(2) < 2 && student.getPesel(2) >= 0 && student.getPesel(3) >= 0 && student.getPesel(3) <3 && student.getPesel(4) < 4 &&  student.getPesel(4) >= 0)
    {
    	if(student.getPesel(4)==3&&(student.getPesel(5)==0||student.getPesel(5)==1))
        {
		cout<<"Podales dobry pesel :D"<<endl;
		}
		else if(student.getPesel(4)==2||student.getPesel(4)==1||student.getPesel(4)==0)
		{
		cout<<"Podales dobry pesel :D"<<endl;	
		}
		else
		{
			cout<<"Zly PESEL"<<endl;
			continue;
		}
    }
    else
    {
        cout<<"Zly PESEL"<<endl;
        //student.setPesel1();
        continue;
    }
 
    cout << "podaj imie studenta:" << endl;
    cin>>imie;
    student.setImie(imie);
 
    cout << "podaj nazwisko studenta:" << endl;
    cin>>nazwisko;
    student.setNazwisko(nazwisko);
 
    
    cout << "Czy chcesz podac adres?(tak/nie)" << endl;
    string wybor1;
    cin>>wybor1;
    if(wybor1 == "tak" || wybor1 == "Tak" || wybor1 == "TAK")
    {
    	cout << "podaj adres studenta:" << endl;
    	cin.clear();
    	cin.ignore(INT_MAX, '\n');
    	getline(cin,adres);
    	student.setAdres(adres);
	}
	else
	{
		student.setAdres("Brak adresu :O");
	}
 
    cout<< "Czy chcesz podac rok?(tak/nie)" << endl;
    string wybor;
    cin>>wybor;
    if(wybor == "tak" || wybor == "Tak" || wybor == "TAK")
    {
	while(rok1<=0||rok1>5)
    {
    cout << "podaj numer roku:" << endl;
    cin>>rok1;
    if(rok1>0&&rok1 <= 5)
    {
    	if(rok1==1) rok="I";
    	else if(rok1==2) rok="II";
    	else if(rok1==3) rok="III";
    	else if(rok1==4) rok="IV";
    	else if(rok1==5) rok="V";
    }
    else
    {
    cout<<"Podaj poprawny rok!"<<endl;
	    }
    }
    student.setRok(rok);
    }
    else if(wybor == "nie" || wybor == "Nie" || wybor == "NIE")
    {
    student.setRok("Brak roku :O");
	}
    
    else
    {
    student.setRok("Brak roku :O");
	}
    VectorStudent.push_back(student);
    
    cout<<"Dodano Studenciaka :D"<< endl;
 
    dodawanieStudenta++;
    break;
    }
 
 
    case 3:  // quit z programu
    {
 
    cout << "Wyjdz z programu" << endl;
    break;
    }
 
 
    default:
    {
 
    cout << "Wybrano bledny numer" << endl;
    break;
    }
    }
}
        return 0;
}
