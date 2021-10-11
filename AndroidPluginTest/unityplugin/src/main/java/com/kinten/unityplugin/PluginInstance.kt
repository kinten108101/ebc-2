package com.kinten.unityplugin

import android.widget.Toast
import com.kinten.unityplugin.PluginInstance
import android.app.Activity
import android.content.Intent
import android.util.Log
import androidx.core.content.ContextCompat.startActivity
import java.io.IOException

class PluginInstance {
    fun Product(a: Int, b: Int): Int {
        return a * b
    }

    fun showText(content: String?) {
        Toast.makeText(unityAct, content, Toast.LENGTH_SHORT).show()
    }
    fun toOtherActivity() {
        val intent = Intent()
        try {
            intent.setClassName("com.kinten.androidplugintest", "mainActivity")
            //startActivity(getApplicationContext,intent)
        } catch(e: IOException) {
            Log.d(TAG, "toOtherActivity: ",e)
        }
    }

    companion object {
        const val TAG = "PluginInstance"
        private var unityAct: Activity? = null
        fun getUnityActivity(activity: Activity?) {
            unityAct = activity
        }
    }
}