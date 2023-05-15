<script setup>

import { latLng } from "leaflet";
import { onMounted, ref } from 'vue';
const samp_dat = ref([])

  onMounted(()=>{
	const options = {
  method: 'GET',
  headers: {}
};


fetch('http://energydashboardapi.azurewebsites.net/api/map?=', options)
.then(response => response.json())
.then(response => {console.log(response); samp_dat.value=response})
.catch(err => console.error(err));
})

</script>


<template>

    <div style="height: 100%; width: 100%">
     
      <l-map
        :zoom="zoom"
        :center="center"
        :options="mapOptions"
        style="height: 100%"
        @update:center="centerUpdate"
        @update:zoom="zoomUpdate"
      >
        <l-tile-layer
          :url="url"
        />
        <l-circle v-for="building, index in samp_dat" :key="index"
        :lat-lng="latLng(building.latitude, building.longitude)"
        :radius="currentZoom < 12 ? building.energyUsage/30 : 50"
        :color="`rgb(${255*(building.energyUsage/150000)},0,${255 - 255*(building.energyUsage/150000)})`"
        
        >


       <l-popup>
            <div @click="innerClick">
              {{building.buildingName}}
              {{building.energyUsage}}
            </div>
          </l-popup>
        </l-circle>

      </l-map>
    </div>
  </template>
  
  <script>
    import "leaflet/dist/leaflet.css";
  import { LMap, LTileLayer, LMarker, LPopup, LTooltip, LCircle} from "@vue-leaflet/vue-leaflet";
  126511

  export default {
    name: "Example",
    components: {
      LMap,
      LTileLayer,
      LMarker,
      LPopup,
      LTooltip,
      LCircle
    }, 
    data() {
      return {
        zoom: 10,
        circle: {
        center: latLng(40.71284288886283, -74.00342815088115),
        radius: 10
      },
        center: latLng(40.71284288886283, -74.00342815088115),
        url: 'http://a.basemaps.cartocdn.com/light_nolabels/{z}/{x}/{y}.png',
        withPopup: latLng(40.71284288886283, -74.00342815088115),
        currentZoom: 11.5,
        currentCenter: latLng(40.71284288886283, -74.00342815088115),
        showParagraph: false,
        mapOptions: {
          zoomSnap: 0.5
        },
        showMap: true
      };
    },
    methods: {
      zoomUpdate(zoom) {
        this.currentZoom = zoom;
      },
      centerUpdate(center) {
        this.currentCenter = center;
      },
      showLongText() {
        this.showParagraph = !this.showParagraph;
      },
      innerClick() {
        alert("Click!");
      }
    }
  };

    

  </script>
  