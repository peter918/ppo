<?php

namespace Scheduler\Models;

use Scheduler\Interfaces\SemesterClassInterface as SemesterClass;
use Scheduler\interfaces\ExtraClassInterface as EventClass;

class Schedule {

	private $classes = [[]];

	private static $week_day_names = [
		"1" => "Poniedziałek",
		"2" => "Wtorek",
		"3" => "Środa",
		"4" => "Czwartek",
		"5" => "Piątek",
	];

	private static $hour_slots = [
		"1" => "08:15-09:45",
		"2" => "10:00-11:30",
		"3" => "11:45-13:15",
		"4" => "13:30-15:00",
		"5" => "15:15-16:45",
		"6" => "17:00-18:30",
		"7" => "18:45-20:15",
	];
	
	

	public function getDays() {
		return self::$week_day_names;
	}


	public function getHours() {
		return self::$hour_slots;
	}

	public function hasClass(int $week_day, int $hour_slot): bool {
		return isset($this->classes[$week_day][$hour_slot]);
	}

	public function getClass(int $week_day, int $hour_slot) {
		return $this->classes[$week_day][$hour_slot];
	}

	public function save(SemesterClass $class, int $week_day, int $hour_slot) {
		$this->classes[$week_day][$hour_slot] = $class;
	}
	
	public function saveEvent(EventClass $class, int $week_day, int $hour_slot) {
		$this->classes[$week_day] [$hour_slot] = $class;
	}	
	
}
