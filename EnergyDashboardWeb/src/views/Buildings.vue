<script setup>
import {ref, onMounted, computed, watch} from 'vue';
const b_num = ref('0')

const samp_dat = ref([])

onMounted(()=>{
	const options = {
  method: 'GET',
  headers: {}
};

fetch('http://localhost:5156/api/energy', options)
  .then(response => response.json())
  .then(response => {console.log(response); samp_dat.value=response})
  .catch(err => console.error(err));
})
</script>


<template>
    <div class="buildingsPage">
        <h1>Buildings</h1>
        <div class="list-group">

            <div class="building_list_item list-group-item">
                <div class="field">BBL</div>
                <div class="field">Name</div>
                <div class="field">Borough</div>
                <div class="field">Building Address</div>
                <div class="field">Energy Usage</div>
                <div class="">Details</div>
            </div>  
            <div v-for="building, index in samp_dat" :key="index" >
                <div class="building_list_item list-group-item" :class="index % 2 == 0 && 'odd'">
                    <div class="field">{{ building.bbl }} </div>
                    <div class="field">{{ building.buildingName }}</div>
                    <div class="field">{{ building.borough }}</div>
                    <div class="field">{{ building.buildingAddress }}</div>
                    <div class="field">{{ building.energyUsage }}</div>
                    <a :href="`/buildings/${building.bbl}`">Details</a>
                </div>    
            </div>
        </div>

  </div>
</template>



<style scoped>
    .building_list_item {
        display: flex;
        flex-direction: row;
        align-items: center;
        justify-content: space-between;
        width: 100%;
        /* margin-bottom: 5px; */
    }
    .field {
        width: 18%;
    }

    .buildingsPage{
        width: 100%;
    }

    .odd {
        background-color: aqua;
    }
</style>

