<?php

namespace Scheduler\Models;

use Scheduler\Interfaces\ExtraClassInterface;

abstract class EventClass implements ExtraClassInterface {

	private $name;
	
	

	public function __construct(string $name) {
		$this->name = $name;
	}

	public function getName(): string {
		return $this->name;
	}
	
	
	

}