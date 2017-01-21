import { Component, OnInit, Input } from '@angular/core';
import { Location } from '@angular/common';

import { AssessmentReport } from '../domain/assessmentreport';
import { AssessmentService } from '../service/assessment.service';


@Component({
  selector: 'app-assessment-create',
  templateUrl: './assessment-create.component.html',
  styleUrls: ['./assessment-create.component.css']
})
export class AssessmentCreateComponent implements OnInit {

  @Input()
  name: string;
  createdAssessment: AssessmentReport;
  errorMessage: string;

  constructor(private location: Location, private assessmentService: AssessmentService) { }



  ngOnInit() {
  }


  goBack(): void {
    this.location.back();
  }

  createAssessment(): void {

    this.assessmentService.createReport(this.name)
      .subscribe(assessment => this.createdAssessment = assessment,
      error => this.errorMessage = <any>error);

      this.location.back();
  }
}
