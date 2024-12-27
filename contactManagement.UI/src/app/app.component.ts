import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

interface contact {
  id: number;
  firstName: string;
  lastName: string;
  email: string;
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  public contacts: contact[] = [];

  constructor(private http: HttpClient) {}

  ngOnInit() {
    //this.getForecasts();
    console.log('app.component');
  }

  getForecasts() {
    this.http.get<contact[]>('api/Contact/GetAll').subscribe(
      (result) => {
        this.contacts = result;
      },
      (error) => {
        console.error(error);
      }
    );
  }

  title = 'contactManagement.UI';
}
