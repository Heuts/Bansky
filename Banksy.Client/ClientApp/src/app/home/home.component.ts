import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html'
})
export class HomeComponent {
  values: string[];

  constructor(private http: HttpClient) {
    this.apiConnectionTest().subscribe(res => (this.values = res));
  }

  apiConnectionTest() {
    return this.http.get<string[]>('https://localhost:44332/api/values');
  }
}