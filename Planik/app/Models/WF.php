<?php

namespace Scheduler\Models;

class WF extends SemesterClass {

	public function getFormName(): string {
		return "W-F";
	}
	
	public function getColor() : string {
		return "magenta";
	}	

}