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
  availableQuantities;

  constructor(private converterService: ConverterService, private fb: FormBuilder) { }

  ngOnInit() {
    this.initializeForm();
    this.converterService.getAllQuantities().subscribe(r => this.availableQuantities = r);
  }

  initializeForm() {
    this.converterForm = this.fb.group({
      valueTo: [],
      valueFrom: [],
      unitTo: ["K", Validators.required],
      unitFrom: ["K", Validators.required],
      quantity: [],
    });
  }

}
