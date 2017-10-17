#include <iostream>
#include <stdlib.h>
#include <time.h>

using namespace std;

class Point {
	public:
		int x;
		int y;
		
		Point() {
			cout << "Point has been created." << endl;
		}
		
		Point(int x, int y) {
			this->x = x;
			this->y = y;
			cout << "Point [" << this->x << ", " << this->y << "] has been created." << endl;
		}
		
		~Point() {
			cout << "Point [" << this->x << ", " << this->y << "] has been deleted." << endl;
		}
		
		void movePoint(int xAxisShift, int yAxisShift) {
			this->x += xAxisShift;
			this->y += yAxisShift;
		}
};

class Circle {
	public:
		Point center;
		int radius;
		
		Circle(Point center, int radius) {
			this->center = center;
			this->radius = radius;
		}
		
		void getCoordinates() {
			cout << "x: " << this->center.x << endl << "y: " << this->center.y << endl;
		}
};
 class Square{
 	public:
 	Point a;
 	Point b;
 	Point c;
 	Point d;
 
 
    Square(Point a,int bok){
 	this->a=a;
 	this->b.x=a.x+bok;
 	this->b.y=a.y;
 	this->c.x=a.x;
 	this->c.y=a.y+bok;
 	this->d.x=c.x+bok;
 	this->d.y=b.y+bok;
 	cout << "\nKwadrat:" << endl;
 	cout << "Punkt(" << this->a.x <<"," << this->a.y << ")"<< endl;
 	cout << "Punkt(" << this->b.x << "," << this->b.y << ")"<< endl;
 	cout << "Punkt(" << this->c.x << ","<< this->c.y << ")"<< endl;
 	cout << "Punkt(" << this->d.x << "," << this->d.y << ")\n"<< endl;
 }

 	
 };

int main() {
	srand(time(NULL));
	
	int inputX = 0, inputY = 0;
	int inputRadius = 5;
	Point p = Point(inputX, inputY);
		
	Square s0 = Square(p, rand() % 50);
	Square s1 = Square(p, rand() % 50);
	Square s2 = Square(p, rand() % 50);
	
	Circle c = Circle(p, inputRadius);
	
	c.center.movePoint(rand() % 10, rand() % 10);
	c.getCoordinates();
	
	return 0;
}

