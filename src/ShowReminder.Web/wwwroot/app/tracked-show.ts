﻿import { TrackedEpisode} from "./tracked-episode";


export class TrackedShow {
    id: number;
    tvdbId: number;
    name: string;
    firstAiredDate: Date;
    airDay: string;
    airTime: string;
    lastEpisodeId: number;
    nextEpisodeId: number;

    lastEpisode: TrackedEpisode;
    nextEpisode: TrackedEpisode;

    detailsExpanded = false;

}