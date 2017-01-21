import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';

import { MaterialModule } from '@angular/material';
import './rxjs-extensions';

import { AppComponent } from './app.component';




import { DashboardComponent } from './dashboard/dashboard.component';
import { AssessmentService } from './service/assessment.service';
import { AppRoutingModule } from './app-routing.module';
import { HeaderComponent } from './header/header.component';
import { AssessmentDetailEditorComponent } from './assessment/assessment-detail-editor.component';
import { AssessmentCreateComponent } from './assessment/assessment-create.component';
import { AssessmentListComponent } from './assessment/assessment-list.component';
import { AssessmentDetailComponent } from './assessment/assessment-detail.component';
import { ResultDetailComponent } from './result/result-detail.component';
import { ResultEditorComponent } from './result/result-editor.component';


@NgModule({
  declarations: [
    AppComponent,
    AssessmentDetailComponent,
    AssessmentListComponent,
    DashboardComponent,
    HeaderComponent,
    AssessmentDetailEditorComponent,
    AssessmentCreateComponent,
    ResultDetailComponent,
    ResultEditorComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    HttpModule,
    AppRoutingModule,
    [MaterialModule.forRoot()]
  ],
  providers: [AssessmentService],
  bootstrap: [AppComponent]
})
export class AppModule { }
