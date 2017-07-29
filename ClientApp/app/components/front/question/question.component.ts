import { Component } from '@angular/core';

import { QuizService } from './../../../services/quiz.service';

@Component({
    selector: 'my-question',
    templateUrl: './quiz.component.html',
    providers: [QuizService]
})
export class QuizComponent {
    constructor(private quizService: QuizService)
    { }

    get bananaTest(): string{
        return this.quizService.greeting;    
    }
}
