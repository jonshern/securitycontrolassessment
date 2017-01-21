import { Component, OnInit } from '@angular/core';

import { Router } from '@angular/router';

import { Observable } from 'rxjs/Rx';

import { AssessmentService } from '../service/assessment.service';
import { AssessmentReport } from '../domain/assessmentreport';




@Component({
    selector: 'app-assessment-list',
    templateUrl: './assessment-list.component.html',
    styleUrls: ['./assessment-list.component.css'],
})
export class AssessmentListComponent implements OnInit {

    selectedAssessment: AssessmentReport;
    errorMessage: string;

    title = 'On Init';

    // assessmentList: AssessmentReport[];
    assessmentList: Observable<AssessmentReport[]>;

    constructor(private router: Router, private assessmentService: AssessmentService) { }

    ngOnInit() {
        this.getAssessments();
    }

    onSelect(assessment: AssessmentReport): void {
        this.selectedAssessment = assessment;
    }


  getAssessments(value?: string) {
    this.assessmentList = this.assessmentService.getAssessmentReports();
  }


    gotoDetail(): void {
        this.router.navigate(['/assessment', this.selectedAssessment.id]);
    }


    openAssessment(id: string): void {
        this.router.navigate(['/assessment', id]);
    }


    newAssessment(): void {
        this.router.navigate(['/createassessment']);
    }
}
