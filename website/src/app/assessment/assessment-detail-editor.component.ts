import { Component, OnInit, Input } from '@angular/core';

import { ActivatedRoute, Params } from '@angular/router';

import { Location } from '@angular/common';

import { AssessmentService } from '../service/assessment.service';
import { AssessmentReport } from '../domain/assessmentreport';
import { AssessmentAnswer } from '../domain/assessmentanswer';

@Component({
  selector: 'app-assessment-detail-editor',
  templateUrl: './assessment-detail-editor.component.html',
  styleUrls: ['./assessment-detail-editor.component.css']
})
export class AssessmentDetailEditorComponent implements OnInit {

   @Input()
    assessment: AssessmentReport;
    assessmentAnswer: AssessmentAnswer[];



  constructor(private assessmentService: AssessmentService, private route: ActivatedRoute, private location: Location) { }

  ngOnInit() {
            // this.route.params
            // .switchMap((params: Params) => this.assessmentService.getAssessment(params['id']))
            // .subscribe(assessment => this.assessment = assessment);
  }

      getAssessmentItems(): void {
        // this.assessmentService.getAssessmentItems().then(assessmentItems => this.assessmentItems = assessmentItems);
    }

        goBack(): void {
        this.location.back();
    }

}
