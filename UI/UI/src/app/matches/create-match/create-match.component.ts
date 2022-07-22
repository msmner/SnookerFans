import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { MatchService } from 'src/app/services/match.service';

@Component({
  selector: 'app-create-match',
  templateUrl: './create-match.component.html',
  styleUrls: ['./create-match.component.css']
})
export class CreateMatchComponent implements OnInit {
  playerForm!: FormGroup;

  constructor(private fb: FormBuilder, private matchService: MatchService, private router: Router) { }

  ngOnInit(): void {
    this.initializeForm();
  }

  initializeForm() {
    this.playerForm = this.fb.group({
      playerOneUserName: ['', Validators.required],
      playerTwoUserName: ['', [Validators.required]],
      score: ['', [Validators.required]],
      playerOneCenturyBreaks: ['', [Validators.required]],
      playerTwoCenturyBreaks: ['', [Validators.required]],
      playerOneHalfCenturyBreaks: ['', [Validators.required]],
      playerTwoHalfCenturyBreaks: ['', [Validators.required]],
      playerOneMaximums: ['', [Validators.required]],
      playerTwoMaximums: ['', [Validators.required]],
      description: ['', [Validators.required]],
    })
  }

  create() {
    this.matchService.createMatch(this.playerForm.value).subscribe({
      complete: () => this.router.navigateByUrl('/matches')
    });
  }
}
