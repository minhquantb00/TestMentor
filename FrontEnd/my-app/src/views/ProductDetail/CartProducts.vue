<template>
  <div>
    <div style="min-height: 72px">
      <HeaderItem></HeaderItem>
    </div>
    <div class="container">
      <div class="cart-product">
        <h2 class="item-content-cart mt-7">Giỏ hàng</h2>
      </div>
      <div class="item-group mb-15 mt-15">
        <h3 class="mb-6">Bạn cũng có thể thích</h3>
        <v-sheet class="mx-auto" elevation="4">
          <v-slide-group v-model="model" center-active show-arrows>
            <v-slide-group-item
              v-for="n in listCourse"
              :key="n.id"
              v-slot="{ toggle }"
            >
              <div
                class="ma-6 course-item"
                @click="toggle"
                style="width: 250px"
              >
                <v-img :src="n.image" width="250px" height="141px" />
                <h4>{{ n.nameCourse }}</h4>
                <p>{{ n.teacher }}</p>
                <p style="margin: 0">{{ n.description }}</p>
                <v-rating
                  v-model="rating"
                  size
                  class="my-2"
                  active-color="orange"
                  color="orange-lighten-1"
                ></v-rating>
                <p style="margin: 0">{{ n.price }}</p>
              </div>
            </v-slide-group-item>
          </v-slide-group>
        </v-sheet>
      </div>
    </div>
    <div>
      <FooterItem></FooterItem>
    </div>
  </div>
</template>

<script>
import HeaderItem from "../Header/HeaderItem.vue";
import FooterItem from "../Header/FooterItem.vue";
import { useRouter } from "vue-router";
import { courseApi } from "@/apis/Course/courseApi";
export default {
  components: {
    HeaderItem,
    FooterItem,
  },
  data() {
    return {
      courseApi: courseApi(),
      listCourse: [],
      params:{
        title: ''
      }
    };
  },
  async mounted(){
    const valueReturn = await this.courseApi.searchCourses(this.params);
    const result = valueReturn.data
    console.log(result)
  }
};
</script>

<style scope>
.item-content-cart{
    font-family: initial;
    font-weight: bold;
    font-size: 40px;
}
</style>
