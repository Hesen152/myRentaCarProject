import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup ,Validators} from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
registerForm:FormGroup;

  constructor(private formBuilder:FormBuilder,
    private authService:AuthService,
    private toastService:ToastrService,
    private router:Router
    ) { }

  ngOnInit(): void {
    this.registerLoginForm()
  }


  registerLoginForm(){
    this.registerForm=this.formBuilder.group({
      firstName:["",Validators.required],
      lastName:["",Validators.required],
      email:["",Validators.required],
      password:["",Validators.required]
    })
  }


  register(){
  if (this.registerForm.valid) {
    console.log(this.registerForm.value)

    let registerModel=Object.assign({},this.registerForm.value);
        this.authService.register(registerModel).subscribe(response=>{
          this.toastService.info(response.message);
          console.log(response);
          setTimeout(() => {
                      this.router.navigate(['/login']);

          }, 2000);
          // localStorage.setItem("token",response.data.token);

        },responseError=>{
          console.log(responseError);
          this.toastService.error(responseError.error);
        })


  }
  }

}
