import { Injectable } from '@angular/core';


@Injectable()
export class HelperService{

    private static _counter: number = 0;

    private static readonly _newEntityId = '_undefinedId_';

    public get undefinedId(): string {
        return HelperService._newEntityId + HelperService._counter++;
    }

    public isNewEntity(entityId: string): boolean {
        return entityId.startsWith(HelperService._newEntityId);
    }
}

