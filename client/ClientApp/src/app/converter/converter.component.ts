import { Component, OnInit } from "@angular/core";
import { FormGroup, Validators, FormBuilder } from "@angular/forms";
import { flatMap, map } from "rxjs/operators";
import { ConverterService, UnitInfo } from "./converter.service";

@Component({
  selector: "app-converter",
  templateUrl: "./converter.component.html",
  styleUrls: ["./converter.component.css"]
})
export class ConverterComponent implements OnInit {

  converterForm: FormGroup;
  availableQuantities;
  units;
  changes;
  isFormReady;

  constructor(private converterService: ConverterService, private fb: FormBuilder) { }

  ngOnInit() {
    this.isFormReady = false;
    this.converterService.getAllQuantities().subscribe(r => {
      this.availableQuantities = r;
      this.initializeForm();
      this.onChanges();
    });

  }

  initializeForm() {
    this.converterForm = this.fb.group({
      valueTo: [],
      valueFrom: [],
      unitTo: ["K", Validators.required],
      unitFrom: ["K", Validators.required],
      quantity: [this.availableQuantities],
    });
    
    this.converterForm.controls["quantity"].setValue(this.availableQuantities[0]);
    this.isFormReady = true;
  }

  onChanges() {

    this.converterService.getAllQuantities().subscribe(r => this.availableQuantities = r);

    this.converterForm.valueChanges.subscribe(val => {
      this.changes = val;
    });

    this.converterForm.controls["quantity"].valueChanges.pipe(
        flatMap(r => this.converterService.getAllUnitsForQuantity(String(r))))
      .subscribe(r => {
        this.units = r;
        this.converterForm.get("unitFrom").setValue(this.units[0].name);
        this.converterForm.get("unitTo").setValue(this.units[1].name);
        console.log(this.units[0].name);
      });

  }

}
