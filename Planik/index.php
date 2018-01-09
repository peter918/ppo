<?php

require "./vendor/autoload.php";


use Scheduler\Models\Lecture; // wykład
use Scheduler\Models\Schedule; // godziny / dni
use Scheduler\Models\Laboratory; //lab
use Scheduler\Models\Exercises; // ćw
use Scheduler\Models\WF; // wf
use Scheduler\Models\event_1; // rektorskie

$twig = new Twig_Environment(new Twig_Loader_Filesystem("/"), []);

$schedule = new Schedule();


//pn
$schedule->save(new Lecture("Bazy danych", "Aleksander Klosow", "C212"), 1, 1);
$schedule->save(new Lecture("Projektowanie i programowanie obiektowe", "Aleksander Klosow", "C212"),1,2);
$schedule->save(new Exercises("Język angielski", "Magdalena Kendziorczyk-Twardoch", "C312"),1,3);
$schedule->save(new Lecture ("Sieci komputerowe", "Piotr Nadybski", "C212"),1,4);

//wt
$schedule->save(new Lecture("Podstawy teorii informacji", "Arkadiusz Grzybowski","A118"),2,3);
$schedule->save(new Lecture("Podstawy teorii informacji", "Arkadiusz Grzybowski", "A118"),2,4);
$schedule->save(new Laboratory("Projektowanie i programowanie obiektowe", "Krzysztof Rewak", "A241"),2,5);
$schedule->save(new Laboratory("Projektowanie i programowanie obiektowe", "Krzysztof Rewak", "A241"),2,6);

// sr
$schedule->save(new Lecture("Podstawy metod probabilistycznych i statystyki", "Karol Selwat", "C212"),3,1);
$schedule->save(new Laboratory("Bazy danych", "Józefa Górska-Zając", "A218"),3,2);
$schedule->save(new Exercises("Podstawy metod probabilistycznych i statystyki", "Karol Selwat", "C222"),3,3);

//czw
$schedule->save(new Laboratory("Sieci komputerowe", "Piotr Nadybski", "C11"),4,5);

//pi
$schedule->save(new WF("Siłownia", "Łukasz Stawarz", "A10"),5,1);
$schedule->save(new WF("Siłownia", "Łukasz Stawarz", "A10"),5,2);
$schedule->saveEvent(new event_1("Godziny rektorskie"),5,3);
$schedule->saveEvent(new event_1("Godziny rektorskie"),5,4);

echo $twig->render("index.twig", [
    "schedule" => $schedule,
]);
