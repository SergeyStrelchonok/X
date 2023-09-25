import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { ThemePalette } from '@angular/material/core';
import { ProgressBarMode } from '@angular/material/progress-bar';
import { NotifyService } from 'src/app/services/notify.service';
import { RegistrationService } from 'src/app/services/registration.service';
import { keyValue } from 'src/app/shared/Interfaces/keyValue.interface';
import { user } from 'src/app/shared/Interfaces/user.interface';
import { PasswordValidator } from 'src/app/shared/validators/password.validator';

@Component({
  selector: 'app-registration-form',
  templateUrl: './registration-form.component.html',
  styleUrls: ['./registration-form.component.css']
})
export class RegistrationFormComponent {

  countries: keyValue[] = [];
  provinces: keyValue[] = [];

  color: ThemePalette = 'primary';
  mode: ProgressBarMode = 'indeterminate';
  value = 0;
  bufferValue = 100;

  isLinear = true;
  isLoading = false;
  isUserSuccessfulyAdded = false;

  constructor(
    private _formBuilder: FormBuilder, 
    private _regService: RegistrationService,
    private _notifyService: NotifyService
    ) {}

ngOnInit() {
  this.isLoading = true;
  this._regService.getAllCountries()
   .subscribe(result =>{
      this.countries = result
      this.secondFormGroup.controls["countryDDCtrl"].enable();
      this.isLoading = false;
    })
  };

  firstFormGroup: any = this._formBuilder.group({
    loginCtrl: ['', [Validators.required, Validators.email]],
    passwordCtrl: ['', [Validators.required, PasswordValidator.OnlyDigitsAndLetters]],
    passwordConfirmCtrl: ['', Validators.required],
    agreeCheckBoxCtrl: ['', Validators.requiredTrue],

  });

  secondFormGroup: any = this._formBuilder.group({
    countryDDCtrl: [{ value:'', disabled: true }, Validators.required],
    provinceDDCtrl: [{ value:'', disabled: true }, Validators.required],
  });

  OnCountryDropDownChanged(event: any)
  {
    this.secondFormGroup.controls["provinceDDCtrl"].disable ();
    const changedCountryId: any = this.secondFormGroup.controls["countryDDCtrl"].value;
    
    if(changedCountryId)
    {
      this.isLoading = true;
      this._regService.getProvincesByCountryId(changedCountryId)
      .subscribe(result =>{
        this.provinces = result
        this.secondFormGroup.controls["provinceDDCtrl"].enable();
        this.isLoading = false;
      })
    };
  }

  confirmPasswordChanged()
  {
    const password = this.firstFormGroup.controls["passwordCtrl"].value;
    const confirmPassword = this.firstFormGroup.controls["passwordConfirmCtrl"].value;

    if(password !=confirmPassword)
      this.firstFormGroup.controls['passwordConfirmCtrl'].setErrors({ notConfirm: true });
  }

  clickOnGoToStep2() {
    this.firstFormGroup.get('agreeCheckBoxCtrl').markAllAsTouched();
  }

  onSaveButtonClick()
  {
    this.isLoading = true;
    const regInfo = this.GetRegistrationInfo();
    
    this._regService.newUser(regInfo)
    .subscribe({
      next: (v) => {
        console.info(v);
        this.isLoading = false;
        this.firstFormGroup.reset();
        this.secondFormGroup.reset();
        this.isUserSuccessfulyAdded = true;
        this._notifyService.success("User added successfully")
      },
      error: (e) => this._notifyService.error(e)
    });
  }

  GetRegistrationInfo() : user{
    return {
      login: this.firstFormGroup.get('loginCtrl').value,
      password: this.firstFormGroup.get('passwordCtrl').value,
      isAgreeToWorkForFood: this.firstFormGroup.get('agreeCheckBoxCtrl').value,
      countryId: this.secondFormGroup.get('countryDDCtrl').value,
      provinceId: this.secondFormGroup.get('provinceDDCtrl').value
    }
  }
}

