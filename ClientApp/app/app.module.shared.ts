import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './components/main/app/app.component'
import { NavMenuComponent } from './components/main/navmenu/navmenu.component';
import { HomeComponent } from './components/main/home/home.component';
import { FetchDataComponent } from './components/front/fetchdata/fetchdata.component';
import { QuizComponent } from './components/front/quiz/quiz.component';

export const sharedConfig: NgModule = {
    bootstrap: [ AppComponent ],
    declarations: [
        AppComponent,
        NavMenuComponent,
        FetchDataComponent,
        HomeComponent,
        QuizComponent,
    ],
    imports: [
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'fetch-data', component: FetchDataComponent },
            { path: 'quiz', component: QuizComponent},
            { path: '**', redirectTo: 'home' }
        ]),
        FormsModule
    ]
};
