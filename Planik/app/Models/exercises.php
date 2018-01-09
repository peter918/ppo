<?php

namespace Scheduler\Models;

class exercises extends SemesterClass {

	public function getFormName(): string {
		return "Ćwiczenia";
	}
	
	public function getColor() : string {
		return  "purple";
	}	

}