import { Component, OnInit } from '@angular/core';
import { Person } from 'src/app/models/Person';
import { PersonService } from 'src/app/services/person.service';

@Component({
  selector: 'app-query',
  templateUrl: './query.component.html',
  styleUrls: ['./query.component.css']
})
export class QueryComponent implements OnInit {

  persons: Person[];
  constructor(private personService: PersonService) { }

  ngOnInit(): void {
    this.loadPerson();
  }

  loadPerson(){
    this.personService.getAll().subscribe(data => {
      this.persons = data;
    })
  }

  deletePerson(id: string){
    this.personService.delete(id).subscribe(data => {
      alert('this person has been remove');
      this.loadPerson();
    });
    alert('this person has been removed');
  }
}
