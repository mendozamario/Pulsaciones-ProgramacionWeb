import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, AbstractControl } from '@angular/forms';
import { Person } from 'src/app/models/Person';
import { PersonService } from 'src/app/services/person.service';

@Component({
  selector: 'app-registry',
  templateUrl: './registry.component.html',
  styleUrls: ['./registry.component.css']
})
export class RegistryComponent implements OnInit {

  formGroup: FormGroup;
  person: Person;
  constructor(private personService: PersonService, private formBuilder: FormBuilder) { }

  ngOnInit(): void {
    this.buildForm();
  }

  private buildForm(){
    this.person = new Person();
    this.person.id = '';
    this.person.name = '';
    this.person.age = 0;
    this.person.gender = '';
    this.person.pulsation = 0;

    this.formGroup = this.formBuilder.group({
      id: [this.person.id, Validators.required],
      name: [this.person.name, Validators.required],
      age: [this.person.age, [Validators.required, Validators.min(1)]],
      gender: [this.person.gender, Validators.required]
    });
  }

  add(){
    this.person = this.formGroup.value;
    this.personService.post(this.person).subscribe(data => {
      if (data != null){
        alert ('Person added');
        this.person = data;
      }
    });
  }

  get control(){
    return this.formGroup.controls;
  }

  onSubmit(){
    if (this.formGroup.invalid){
      return ;
    }
    this.add();
  }
}
