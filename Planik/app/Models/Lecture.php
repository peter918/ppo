<?php

namespace Scheduler\Models;

class Lecture extends SemesterClass {

	public function getFormName(): string {
		return "Wykład";
	}
	
	public function getColor () :string {
		return "green";
	}

}