<?php

namespace Scheduler\Models;

use Scheduler\Interfaces\SemesterClassInterface;

abstract class SemesterClass implements SemesterClassInterface {

	private $name; // nazwa przedmiotu
	private $lecturer; // wykładowca
	private $sala; //salka
	

	public function __construct(string $name, string $lecturer, string $sala) {
		$this->name = $name;
		$this->lecturer = $lecturer;
		$this->sala = $sala;
	}

	public function getName(): string {
		return $this->name;
	}
	
	public function getLecturer(): string {
		return $this->lecturer;
	}

	public function getSala(): string {
		return $this->sala;
	}

}
