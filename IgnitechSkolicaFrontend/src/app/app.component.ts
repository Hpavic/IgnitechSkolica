import { Component } from '@angular/core';
import { RouterOutlet, Router } from '@angular/router';
import { NgClass } from '@angular/common';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, NgClass],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'IgnitechSkolicaFrontend';
  activeRoute: string = '';

  constructor(private router: Router) {}

  navigateToHome(): void {
    this.activeRoute = '';
    this.router.navigate(['/']);
  }

  navigateToTeachers(): void {
    this.activeRoute = 'teachers';
    this.router.navigate(['/teachers']);
  }

  navigateToStudents(): void {
    this.activeRoute = 'students';
    this.router.navigate(['/students']);
  }

  navigateToSubjects(): void {
    this.activeRoute = 'subjects';
    this.router.navigate(['/subjects']);
  }

  navigateToGrades(): void {
    this.activeRoute = 'grades';
    this.router.navigate(['/grades']);
  }

  isActive(route: string): boolean {
    return this.activeRoute === route;
  }
}
