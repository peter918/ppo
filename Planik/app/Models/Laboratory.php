<?php

namespace Scheduler\Models;

class Laboratory extends SemesterClass {

	public function getFormName(): string {
		return "Laboratorium";
	}
	
	public function getColor() : string {
		return "red";
	}	

}