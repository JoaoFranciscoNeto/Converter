import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import { ConverterService } from "./converter.service";

@Component({
  selector: 'app-converter',
  templateUrl: './converter.component.html',
  styleUrls: ['./converter.component.css']
})
export class ConverterComponent implements OnInit {

  converterForm: FormGroup;
  constructor(private converterService: ConverterService) { }

  ngOnInit() {
    this.initializeForm();
  }

  initializeForm() {
    this.converterForm = new FormGroup({
      value: new FormControl(),
      source: new FormControl(),
      target: new FormControl(),
    });
  }

}
