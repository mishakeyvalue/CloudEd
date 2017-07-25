import { Injectable } from '@angular/core';
import { Quiz } from './quiz';

@Injectable()
export class QuizService {

    constructor() { }

    GetAll(): Quiz[] {
        return this.getStubbedQuizes();
    }

    private getStubbedQuizes(): Quiz[]{
        return [
            {
                Questions: [
                    
                }
                ]
            }
        ];
    }
    

}