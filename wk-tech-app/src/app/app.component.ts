import { Component } from '@angular/core';
import { RouterLink, RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, RouterLink],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
  title = 'wk-tech-app';
  imgUrl = 'https://wktechnology.com.br/wp-content/uploads/2021/10/Logo-WK-rgb-2021.png';
}
