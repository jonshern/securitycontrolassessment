import { Component, OnInit, Input } from '@angular/core';
import { FormGroup, FormControl, Validator, FormBuilder, FormArray } from '@angular/forms';

import { Router, ActivatedRoute, Params } from '@angular/router';
import { Location } from '@angular/common';

import { Observable } from 'rxjs/Rx';

import { AssessmentAnswer } from '../domain/assessmentanswer';
import { AssessmentService } from '../service/assessment.service';


@Component({
  selector: 'app-result-editor',
  templateUrl: './result-editor.component.html',
  styleUrls: ['./result-editor.component.css']
})
export class ResultEditorComponent implements OnInit {


  asessmentAnswer = new AssessmentAnswer();


  policyDefined: string;

  policyDefault = 'Approved Written Policy';


  policyChoices = [
    'No Policy',
    'Informal Policy',
    'Written Policy',
    'Approved Written Policy'
  ];

  controlChoices = [
    'Not Implemented',
    'Parts of Policy Implemented',
    'Implemented on Some Systems',
    'Implemented on Most System',
    'Implemented on All Systems'
  ];

  automationChoices = [
    'Not Automated',
    'Implemented on Some Automated',
    'Implemented on Most Automated',
    'Implemented on All Automated'
  ];

  reportingChoices = [
    'Not Reported',
    'Reported on Some Systems',
    'Reported on Most Systems',
    'Reported on All Systems'
  ];





  constructor(private formBuilder: FormBuilder, private activatedRoute: ActivatedRoute, private location: Location,
    private assessmentService: AssessmentService) {

  }

  ngOnInit() {
    this.getAssessmenAnswer(this.activatedRoute.snapshot.params['id']);
  }


  getAssessmenAnswer(id: string) {
    this.assessmentService.getAssessmentAnswer(id)
      .subscribe(
      (data: AssessmentAnswer) => this.asessmentAnswer = data
      ,
      (e => console.log(e))
      ,
      () => this.getAssessmentCompleted()
      );
  }


  getAssessmentCompleted(){
      // this.policyDefault = this.asessmentAnswer.policyDefined;
  }

  saveAssessmentAnswer() {
    this.assessmentService.saveAssessmentAnswer(this.asessmentAnswer.id, this.asessmentAnswer)
      .subscribe(() =>  console.log('retrieved data')
      );

      this.location.back();
  }

  onCancel() {
    this.location.back();
  }
}
