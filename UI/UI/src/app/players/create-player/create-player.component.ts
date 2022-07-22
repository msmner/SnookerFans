import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { PlayerService } from 'src/app/services/player.service';

@Component({
  selector: 'app-create-player',
  templateUrl: './create-player.component.html',
  styleUrls: ['./create-player.component.css']
})
export class CreatePlayerComponent implements OnInit {
  playerForm!: FormGroup;

  constructor(private fb: FormBuilder, private playerService: PlayerService, private router: Router) { }

  ngOnInit(): void {
    this.initializeForm();
  }

  initializeForm() {
    this.playerForm = this.fb.group({
      username: ['', Validators.required],
      nationality: ['', [Validators.required]],
      description: ['', [Validators.required]],
    })
  }

  create() {
    this.playerService.createPlayer(this.playerForm.value).subscribe({
      complete: () => this.router.navigateByUrl('/players')
    });
  }
}
